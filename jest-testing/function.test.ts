import { service } from "./function";

describe("functions", () => {
  it("service sum", () => {
    expect(service.sum(2, 2)).toBe(4);
  });

  it("get user", async () => {
    const user = await service.getUser();
    expect(user.name).toBe("Leanne Graham");
    console.log(user);
  });
});
