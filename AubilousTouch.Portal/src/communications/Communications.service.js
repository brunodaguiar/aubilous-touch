import axios from 'axios';
const axiosInstance = axios.create({
  baseURL: 'http://localhost:17504/',
});

export const getCommunications = async (callback) => {
  return await axiosInstance
    .get('api/messages')
    .then((res) => {
      console.log(res);
      callback(res.data);
    })
    .catch((error) => {
      console.log('Api call error');
      console.log(error);
      alert(error.message);
    });
};