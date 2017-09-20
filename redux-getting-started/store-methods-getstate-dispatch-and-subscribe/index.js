const counter = (state = 0, { type }) => {
  switch (type) {
    case "INCREMENT":
      return state + 1;
    case "DECREMENT":
      return state - 1;
    default:
      return state;
  }
};

const { createStore } = Redux;
const store = createStore(counter);
const render = () => {
  console.log(store.getState());
  document.body.innerHTML = store.getState();
};

store.subscribe(render);
render();

document.addEventListener("click", () => store.dispatch({ type: "INCREMENT" }));
