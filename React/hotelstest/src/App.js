import React from "react";
import {BrowserRouter as Router , Switch, Route, Link } from 'react-router-dom';
import GetHotels from "./Components/GetHotels";
import HotelComponent from "./Components/HotelComponent";
import Home from "./Components/Home.js";

import './App.css';
import './css/button.css';
import './css/Table.css';

function App() {
  return (
    <div className="App">
      <Router>
      <nav>
        
        <Link to="/AllHotels">
          <button style={{ marginRight: "auto" }}>Get All Hotel</button>
        </Link>
        <Link to="/AddHotel">
        <button style={{ marginRight: "auto" }}>Add Hotels</button>
        </Link>
      </nav>

    <Switch>
      <Route path="/" component={Home} exact/>
      <Route path="/AllHotels" component={GetHotels}/>
      <Route path="/AddHotel" component={HotelComponent}/>

    </Switch>

    </Router>

    </div>
  );
}

export default App;
