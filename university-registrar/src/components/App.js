import React from 'react';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { reducers } from '../reducers/index';
import { BrowserRouter, Route } from 'react-router-dom';

import Students from './students/Students';
import StudentDelete from './students/StudentDelete';
import StudentEdit from './students/StudentEdit';
import StudentDetails from './students/StudentDetails';
import StudentNew from './students/StudentNew';
import Courses from './courses/Courses';
import CourseDelete from './courses/CourseDelete';
import CourseDetails from './courses/CourseDetails';
import CourseEdit from './courses/CourseEdit';
import CourseNew from './courses/CourseNew';
import Landing from './Landing';

const store = createStore(reducers, applyMiddleware(thunk));

function App() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <div>
          <Route path='/' exact component={Landing} />
          <Route path='/students' exact component={Students} />
          <Route path='/students/new' exact component={StudentNew} />
          <Route path='/students/edit' exact component={StudentEdit} />
          <Route path='/students/delete' exact component={StudentDelete} />
          <Route path='/students/details' exact component={StudentDetails} />
          <Route path='/courses' exact component={Courses} />
          <Route path='/courses/new' exact component={CourseNew} />
          <Route path='/courses/edit' exact component={CourseEdit} />
          <Route path='/courses/delete' exact component={CourseDelete} />
          <Route path='/courses/details' exact component={CourseDetails} />
        </div>
      </BrowserRouter>
    </Provider>
  );
}

export default App;
