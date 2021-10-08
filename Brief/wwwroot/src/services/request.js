import axios from 'axios';

const service = axios.create({
  baseURL: 'https://localhost:44314/',
  timeout: 600000,
});

export default service;
