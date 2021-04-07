import axios from "axios";

export const service = {
  sum: (num1: number, num2: number) => num1 + num2,
  getUser: async () => {
    return await (
      await axios.get("https://jsonplaceholder.typicode.com/users/1")
    ).data;
  },
};
