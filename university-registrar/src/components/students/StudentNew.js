import React from 'react';
import * as actions from '../../actions/students';
import { connect } from 'react-redux';

const StudentNew = props => {
  const onStudentFormSubmit = event => {
    event.preventDefault();
    const newStudent = {
      name: event.target.name.value,
      enrollmentDate: event.target.enrollment.value
    };
    props.createStudent(newStudent);
  };

  return (
    <React.Fragment>
      <form onSubmit={onStudentFormSubmit}>
        <input type='text' name='name' placeholder='Your Name' />
        <input type='text' name='enrollment' placeholder='05/08/2020' />
        <button type='submit'>Add New Student</button>
      </form>
    </React.Fragment>
  );
};

const mapActionToProps = {
  createStudent: actions.create,
  updateStudent: actions.update
};

export default connect(null, mapActionToProps)(StudentNew);
