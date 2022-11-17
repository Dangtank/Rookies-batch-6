import axios from 'axios';
import { BASE_URL, TOKEN_KEY } from '../constants';

export async function logIn(loginInfo) {
  const url = `${BASE_URL}/Authenticate/login`;

  let response = undefined;

  await axios
    .post(url, loginInfo)
    .then((result) => {
      response = result.data;
      localStorage.setItem(TOKEN_KEY, response.accessToken);
      localStorage.setItem('userName', response.user)

    })
    .catch((error) => {
      console.log({ error });
    });

  return response;
}
