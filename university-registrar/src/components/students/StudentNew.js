import React from 'react';

const StudentNew = () => {
  const onStudentFormSubmit = event => {
    event.preventDefault();
    console.log('hello');
  };

  return (
    <React.Fragment>
      <form onSubmit={onStudentFormSubmit}>
        <input type='text' name='names' placeholder='Pair Names' />
        <input type='text' name='location' placeholder='Location' />
        <textarea name='issue' placeholder='Describe your issue.' />
        <button type='submit'>Add New Student</button>
      </form>
    </React.Fragment>
  );
};

export default StudentNew;
