import sum from '../src/sum';

describe("sum", () => {
  it("2 + 2 = 5", () => {
    assert(sum(2, 2) === 5);
  });
});