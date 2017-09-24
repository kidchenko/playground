(function(store) {
  let nextTodoId = 0;
  const { Component } = React;
  const { connect, Provider } = ReactRedux;

  const addTodo = text => {
    return {
      type: "ADD_TODO",
      id: nextTodoId++,
      text
    };
  };

  const setVisibilityFilter = filter => {
    return {
      type: "SET_VISIBILITY_FILTER",
      filter
    };
  };

  const toggleTodo = id => {
    return {
      type: "TOGGLE_TODO",
      id
    };
  };

  const filterTodos = (todos, visibilityFilter) => {
    switch (visibilityFilter) {
      case "SHOW_ALL":
        return todos;
      case "SHOW_ACTIVE":
        return todos.filter(t => !t.completed);
      case "SHOW_COMPLETED":
        return todos.filter(t => t.completed);
      default:
        return todos;
    }
  };

  // *** ADD TODO

  let AddTodo = ({ dispatch }) => {
    let input;
    return (
      <form
        onSubmit={e => {
          e.preventDefault();
          if (input.value.trim()) {
            dispatch(addTodo(input.value));
            input.value = "";
          }
        }}
      >
        <input
          ref={node => {
            input = node;
          }}
        />
        <button type="submit">Add Todo</button>
      </form>
    );
  };
  AddTodo = connect()(AddTodo);

  // *** DISPLAY TODO

  const Todo = ({ onClick, completed, text }) => (
    <li
      onClick={onClick}
      style={{
        textDecoration: completed ? "line-through" : "none",
        color: completed ? "green" : "inherit"
      }}
    >
      {text}
    </li>
  );
  const TodoList = ({ todos, onTodoClick }) => (
    <ul>
      {todos.map(todo => (
        <Todo key={todo.id} {...todo} onClick={() => onTodoClick(todo.id)} />
      ))}
    </ul>
  );
  const mapStateToTodoListProps = state => {
    return {
      todos: filterTodos(state.todos, state.visibilityFilter)
    };
  };
  const mapDispatchToTodoListProps = dispatch => {
    return {
      onTodoClick: id => store.dispatch(toggleTodo(id))
    };
  };
  const VisibleTodoList = connect(
    mapStateToTodoListProps,
    mapDispatchToTodoListProps
  )(TodoList);

  // *** FOOTER

  const Link = ({ active, children, onClick }) => {
    if (active) return <span>{children}</span>;
    return (
      <a
        href="#"
        onClick={e => {
          e.preventDefault();
          onClick();
        }}
      >
        {children}
      </a>
    );
  };

  const mapStateToLinkProps = (state, ownProps) => {
    return {
      active: ownProps.filter === state.visibilityFilter
    };
  };
  const mapDispatchToLinkProps = (dispatch, ownProps) => {
    return {
      onClick: () => {
        dispatch(setVisibilityFilter(ownProps.filter));
      }
    };
  };
  const FilterLink = connect(mapStateToLinkProps, mapDispatchToLinkProps)(Link);

  const Footer = ({ store }) => (
    <p>
      Show: <FilterLink filter="SHOW_ALL"> ALL</FilterLink> |
      <FilterLink filter="SHOW_ACTIVE"> ACTIVE</FilterLink> |
      <FilterLink filter="SHOW_COMPLETED"> COMPLETED</FilterLink>
    </p>
  );

  // *** APP

  const TodoApp = () => (
    <div>
      <AddTodo />
      <VisibleTodoList />
      <Footer />
    </div>
  );

  ReactDOM.render(
    <Provider store={store}>
      <TodoApp />
    </Provider>,
    document.getElementById("root")
  );
})(window.store);
