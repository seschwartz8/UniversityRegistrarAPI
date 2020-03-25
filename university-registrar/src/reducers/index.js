import { combineReducers } from 'redux';
import { student } from './student';
import { course } from './course';

export const reducers = combineReducers({
  student,
  course
});
