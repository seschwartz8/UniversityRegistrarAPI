import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
// import Header from './Header';

const App = () => {
  // Header component is nested in router to allow use of links, but does not have a route asigned so it's always visible

  return (
    <BrowserRouter>
      <div>
        {/* <Header /> */}
        <Route path='/' exact component={} />
        <Route path='/' exact component={} />
        <Route path='/' exact component={} />
        <Route path='/' exact component={} />
        <Route path='/' exact component={} />
      </div>
    </BrowserRouter>
  );
};

export default App;
