const store = (function() {
  const todo = (state, action) => {
    switch (action.type) {
      case "ADD_TODO":
        return {
          id: action.id,
          text: action.text,
          completed: false
        };
      case "TOGGLE_TODO":
        if (state.id !== action.id) {
          return state;
        }
        return {
          ...state,
          completed: !state.completed
        };
      default:
        state;
    }
  };

  const todos = (state = [], action) => {
    switch (action.type) {
      case "ADD_TODO":
        return [...state, todo(undefined, action)];
      case "TOGGLE_TODO":
        return state.map(t => todo(t, action));
      default:
        return state;
    }
  };

  const visibilityFilter = (state = "SHOW_ALL", action) => {
    switch (action.type) {
      case "SET_VISIBILITI_FILTER":
        return action.filter;
      default:
        return state;
    }
  };

  const { createStore, combineReducers } = Redux;
  const todoApp = combineReducers({
    todos,
    visibilityFilter
  });
  const store = createStore(todoApp);
  return store;
})();

(function(store) {
  let nextTodoId = 0;
  const { Component } = React;

  const FilterLink = ({ filter, current, children }) => {
    return filter === current ? (
      <span>{children}</span>
    ) : (
      <a
        href="#"
        onClick={e => {
          e.preventDefault();
          store.dispatch({
            type: "SET_VISIBILITI_FILTER",
            filter
          });
        }}
      >
        {children}
      </a>
    );
  };

  class TodoApp extends Component {
    filterTodos = (todos, visibilityFilter) => {
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

    render() {
      const { visibilityFilter } = this.props;
      const filteredTodos = this.filterTodos(
        this.props.todos,
        visibilityFilter
      );
      return (
        <div>
          <form
            onSubmit={e => {
              e.preventDefault();
              store.dispatch({
                type: "ADD_TODO",
                text: this.input.value,
                id: nextTodoId++
              });
              this.input.value = "";
            }}
          >
            <input
              ref={node => {
                this.input = node;
              }}
            />
            <button type="submit">Add Todo</button>
          </form>
          <ul>
            {filteredTodos.map(todo => (
              <li
                key={todo.id}
                onClick={() =>
                  store.dispatch({
                    type: "TOGGLE_TODO",
                    id: todo.id
                  })}
                style={{
                  textDecoration: todo.completed ? "line-through" : "none",
                  color: todo.completed ? "green" : "inherit"
                }}
              >
                {todo.text}
              </li>
            ))}
          </ul>
          <p>
            Show:{" "}
            <FilterLink filter="SHOW_ALL" current={visibilityFilter}>
              {" "}
              ALL
            </FilterLink>{" "}
            |
            <FilterLink filter="SHOW_ACTIVE" current={visibilityFilter}>
              {" "}
              ACTIVE
            </FilterLink>{" "}
            |
            <FilterLink filter="SHOW_COMPLETED" current={visibilityFilter}>
              {" "}
              COMPLETED
            </FilterLink>
          </p>
        </div>
      );
    }
  }

  const render = () => {
    ReactDOM.render(
      <TodoApp {...store.getState()} />,
      document.getElementById("root")
    );
  };

  store.subscribe(render);
  render();
})(store);
