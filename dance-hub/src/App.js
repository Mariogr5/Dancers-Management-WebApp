import React, { useState, useEffect } from 'react';
import Dashboard from './components/Dashboard/Dashboard';
import Preferences from './components/Preferences/Preferences';
import {Login, LoggedIn} from './components/Login/Login';
import Signup from './components/Signup/Signup';
import { BrowserRouter, Route, Routes, Navigate, useNavigate, Link} from 'react-router-dom';
import useToken from './components/useToken';

function EventList() {
  const [events, setEvents] = useState([]);

  useEffect(() => {
    fetch('https://localhost:7234/DanceEvent')
      .then(response => response.json())
      .then(data => setEvents(data));
  }, []);

  return (
    <div>
      <h2>Lista Wydarzeń</h2>
      <ul>
        {events.map(event => (
          <li key={event.id}>{event.name}</li>
        ))}
      </ul>
    </div>
  );
}

function App() {
  const { token, setToken, logout } = useToken();

  if(token){
    return (
      <div>
        <div className="wrapper">
          <h1>Application</h1>
          <BrowserRouter>
            <Routes>
              <Route path="/dashboard" element={<Dashboard/>} />
              <Route path="/preferences" element={<Preferences/>} />
              <Route path="/login" element={<LoggedIn/>} />
              <Route path="/sign-up" element={<LoggedIn/>} />
            </Routes>
          </BrowserRouter>
        </div>

        <div className="col-md-9">
          <EventList />
        </div>

        <button onClick={() => {logout();}}>Wyloguj się</button>

      </div>
    );
  }
  return (
      <BrowserRouter>
        <Routes>
          <Route path="/dashboard" element={token ? <Dashboard /> : <Login setToken={setToken} />} />
          <Route path="/preferences" element={token ? <Preferences /> : <Login setToken={setToken} />} />
          <Route path="/login" element={token ? <Login /> : <Login setToken={setToken} />} />
          <Route path="/sign-up" element={<Signup/>} />
        </Routes>
      </BrowserRouter>
    );
}

export default App;
