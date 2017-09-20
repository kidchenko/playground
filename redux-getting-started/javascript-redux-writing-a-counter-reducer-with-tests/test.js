import test from "ava";
import counter from "./index";

test(t => {
  t.is(counter(0, { type: "INCREMENT" }), 1);
});

test(t => {
  t.is(counter(1, { type: "INCREMENT" }), 2);
});

test(t => {
  t.is(counter(2, { type: "DECREMENT" }), 1);
});

test(t => {
  t.is(counter(1, { type: "DECREMENT" }), 0);
});

test(t => {
  t.is(counter(1, { type: "JUCA" }), 1);
});

test(t => {
  t.is(counter(undefined, {}), 0);
});
