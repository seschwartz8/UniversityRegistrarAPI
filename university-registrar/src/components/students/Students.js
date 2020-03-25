import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from '../../actions/students';

const Students = props => {
  // const [currentId, setCurrentId] = useState(0);

  //react hook use effext imported from useEffect
  useEffect(() => {
    props.fetchAllStudents();
  }, []);

  const renderStudentList = () => {
    const studentListHTML = props.studentList.map(student => {
      return <p>{student.Name}</p>;
    });
    return studentListHTML;
  };

  return <div>{renderStudentList()}</div>;
};

const mapStateToProps = state => ({
  studentList: state.student.list
});

const mapActionToProps = {
  fetchAllStudents: actions.fetchAll
  // deleteStudent: actions.Delete
};

export default connect(mapStateToProps, mapActionToProps)(Students);
