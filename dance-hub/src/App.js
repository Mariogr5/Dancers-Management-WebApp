import React from 'react';
import Dashboard from './components/Dashboard/Dashboard';
import Preferences from './components/Preferences/Preferences';
import { Login, LoggedIn } from './components/Login/Login';
import Signup from './components/Signup/Signup';
import Navbar from './components/Navbar/Navbar';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import useToken from './components/useToken';
import EventDetails from './components/EventDetails/EventDetails';
import EventDelete from './components/EventDelete/EventDelete';
import Clubs from './components/Clubs/Clubs';
import ClubDetails from './components/ClubDetails/ClubDetails';
import Dancers from './components/Dancers/Dancers';
import EventAdd from './components/EventAdd/EventAdd';
import EventCategory from './components/EventCategory/EventCategory';

function App() {
  const { token, setToken } = useToken();

  if (token) {
    return (
      <BrowserRouter>
        <Routes>
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/preferences" element={<Preferences />} />
          <Route path="/login" element={<LoggedIn />} />
          <Route path="/sign-up" element={<LoggedIn />} />
          <Route path="/" element={<Dashboard />} />
          <Route path="/event/:id" element={<EventDetails />} />
          <Route path="/event/delete/:id" element={<EventDelete />} />
          <Route path="/clubs" element={<Clubs />} />
          <Route path="/club/:id" element={<ClubDetails />} />
          <Route path="/dancers" element={<Dancers />} />
          <Route path="/eventAdd" element={<EventAdd />} />
          <Route path="/event/category/:id" element={<EventCategory />} />
        </Routes>
      </BrowserRouter>
    );
  }
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/preferences" element={<Preferences />} />
        <Route path="/login" element={token ? <Login /> : <Login setToken={setToken} />} />
        <Route path="/sign-up" element={<Signup />} />
        <Route path="/" element={<Dashboard />} />
        <Route path="/event/:id" element={<EventDetails />} />
        <Route path="/clubs" element={<Clubs />} />
        <Route path="/club/:id" element={<ClubDetails />} />
        <Route path="/dancers" element={<Dancers />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
