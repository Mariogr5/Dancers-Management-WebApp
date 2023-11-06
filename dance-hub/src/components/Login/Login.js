import React, { useState } from 'react';
import PropTypes from 'prop-types';
import './Login.css';
import { Navigate } from 'react-router-dom';

export function Login({ setToken }) {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log(email, password);

    // Wyślij żądanie do API w celu uwierzytelnienia
    try {
      const response = await fetch('https://localhost:7234/account/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
      });

      if (response.ok) {
        const data = await response.text();
        // Ustaw token w stanie aplikacji
        setToken(data);
        sessionStorage.setItem('token', data);
      } else {
        // Obsłuż błąd logowania, na przykład wyświetl komunikat o błędzie
        console.error('Błąd logowania');
      }
    } catch (error) {
      console.error('Wystąpił błąd:', error);
    }
  };

  return (
    <div className="row justify-content-center top-50 start-50 position-absolute translate-middle">
      <div className='text-center'>
        <i class="fa-solid fa-users-line fa-bounce"></i>
        <p className="mb-5 fs-2">Witamy ponownie!</p>
        <form onSubmit={handleSubmit}>
          <div className="row">
            <div className="col-lg-6 col-md-6 mb-4">
              <div className="form-floating">
                <input type="email" className="form-control" id="floatingInputGridEmail" placeholder="" value={email} onChange={(e) => setEmail(e.target.value)}/>
                <label>Adres email</label>
              </div>
            </div>
            <div className="col-lg-6 col-md-6 mb-4">
              <div className="form-floating">
                <input type="password" className="form-control" id="floatingInputGridPassword" placeholder="" value={password} onChange={(e) => setPassword(e.target.value)}/>
                <label>Hasło</label>
              </div>
            </div>
          </div>
            <button className="btn btn-outline-primary mb-4" type="submit">Zaloguj się</button>
            <div class="text-center">
              <p>Nie masz konta? <a href="/sign-up">Zarejestruj się!</a></p>
            </div>
        </form>
      </div>
    </div>
  );
}

export function LoggedIn() {
  window.location.href="/dashboard";
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired
}