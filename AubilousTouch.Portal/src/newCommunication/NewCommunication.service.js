import axios from 'axios';
const axiosInstance = axios.create({
  baseURL: 'http://localhost:17504/',
});

export const sendNewCommunication = async ({title,text,file}) => {
  return await axiosInstance 
    .post('api/contact/send-communication',{title,text,file})
    .then((res) => {
      console.log(res);
    })
    .catch((error) => {
      console.log('Api call error');
      console.log(error);
      alert(error.message);
    });
};
