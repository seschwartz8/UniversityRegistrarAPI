import api from './api';

export const ACTION_TYPES = {
  CREATE: 'CREATE',
  UPDATE: 'UPDATE',
  DELETE: 'DELETE',
  FETCH_ALL: 'FETCH_ALL'
};

export const fetchAll = () => dispatch => {
  api
    .student()
    .fetchAll()
    .then(response => {
      dispatch({
        type: ACTION_TYPES.FETCH_ALL,
        payload: response.data
      });
    })
    .catch(err => console.log(err));
};

export const create = data => dispatch => {
  api
    .student()
    .create(data)
    .then(res => {
      dispatch({
        type: ACTION_TYPES.CREATE,
        payload: res.data
      });
    })
    .catch(err => console.log(err));
};

export const update = (id, data) => dispatch => {
  api
    .student()
    .update(id, data)
    .then(() => {
      dispatch({
        type: ACTION_TYPES.UPDATE,
        payload: { id, ...data }
      });
    })
    .catch(err => console.log(err));
};

export const Delete = id => dispatch => {
  api
    .student()
    .delete(id)
    .then(() => {
      dispatch({
        type: ACTION_TYPES.DELETE,
        payload: id
      });
    })
    .catch(err => console.log(err));
};
