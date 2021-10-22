import axios from 'axios';

const requestsUrl = process.env.NODE_ENV === 'development'
  ? 'https://localhost:44314/'
  : undefined;

const service = axios.create({
  baseURL: requestsUrl,
  timeout: 600000,
});

export default service;
