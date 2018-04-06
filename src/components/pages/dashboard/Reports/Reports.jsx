import React, { PropTypes, Component } from 'react';
import { Link } from "react-router";
import { Jumbotron } from 'react-bootstrap';
import { List } from '../../../common/list/List.jsx';

var Buttons = React.createClass({
  render: function() {
    return (

      <div key="reports" className="reports-page">
        <div className="ng-scope"> 
          <Link to="/dashboard/overview" className="pull-right btn btn-primary btn-outline btn-rounded">Back to Overview</Link> 
          <h2>Búsqueda de lugares para tocar</h2> 
          <Jumbotron> 
            <h1></h1>
            <List />  
            <p> <a className="btn btn-primary btn-lg btn-outline btn-rounded">Learn more</a> </p> 
          </Jumbotron> 
        </div>
      </div>
      
    );
  }

});

export default Buttons;