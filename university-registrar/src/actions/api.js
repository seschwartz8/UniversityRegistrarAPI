import axios from 'axios';

const baseUrl = 'http://localhost:5000/';

export default {
  student(url = baseUrl + 'students/') {
    return {
      fetchAll: () => axios.get(url),
      fetchById: id => axios.get(url + id),
      create: newRecord => axios.post(url, newRecord),
      update: (id, updateRecord) => axios.put(url + id, updateRecord),
      delete: id => axios.delete(url + id)
    };
  },

  course(url = baseUrl + 'courses/') {
    return {
      fetchAll: () => axios.get(url),
      fetchById: id => axios.get(url + id),
      create: newRecord => axios.post(url, newRecord),
      update: (id, updateRecord) => axios.put(url + id, updateRecord),
      delete: id => axios.delete(url + id)
    };
  }
};
