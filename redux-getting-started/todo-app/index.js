var store = (function() {
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
console.log(store);
(function(store) {
  let nextTodoId = 0;
  const { Component } = React;

  class TodoApp extends Component {
    render() {
      return (
        <div>
          <button
            onClick={() => {
              store.dispatch({
                type: "ADD_TODO",
                text: "Juca",
                id: nextTodoId++
              });
            }}
          >
            Add Todo
          </button>
          <ul>
            {this.props.todos.map(todo => <li key={todo.id}>{todo.text}</li>)}
          </ul>
        </div>
      );
    }
  }

  const render = () => {
    ReactDOM.render(
      <TodoApp todos={store.getState().todos} />,
      document.getElementById("root")
    );
  };

  store.subscribe(render);
  render();
})(store);
