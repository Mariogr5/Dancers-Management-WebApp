import React, { useState } from 'react';
import PropTypes from 'prop-types';
import './Signup.css';

export default function Signup() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [name, setName] = useState('');
  const [surname, setSurname] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [roleId, setRoleId] = useState(1);
  const fullName = `${name} ${surname}`;
  const [isSuccessful, setIsSuccessful] = useState(false);
  const [emailIsInvalid, setEmailIsInvalid] = useState(false);
  const [passwordIsInvalid, setPasswordIsInvalid] = useState(false);
  const [confirmPasswordIsInvalid, setConfirmPasswordIsInvalid] = useState(false);
  const [errorEmail, setErrorEmail] = useState('');
  const [errorConfirmPassword, setErrorConfirmPassword] = useState('');
  const [errorPassword, setErrorPassword] = useState('');
  


  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('https://localhost:7234/account/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name: fullName, email, password, confirmPassword, roleId }),
      });

      if (response.ok) {
        setIsSuccessful(true);
      } else {
        let data = await response.json();
        data = data.errors;
        const errorKeys = Object.keys(data);
        setIsSuccessful(false);
        setEmailIsInvalid(false);
        setConfirmPasswordIsInvalid(false);
        setPasswordIsInvalid(false);
        setErrorPassword('');

        errorKeys.forEach((errorKey) => {
            data[errorKey].forEach((errorMessage) => {
                  console.log(errorMessage);
                  console.log(errorKey);
                  if(errorKey === 'ContactEmail'){
                    setEmailIsInvalid(true);
                    setErrorEmail(errorMessage);
                  }
                  if(errorKey === 'ConfirmPassword'){
                    setConfirmPasswordIsInvalid(true);
                    setErrorConfirmPassword(errorMessage);
                  }
                  if(errorKey === 'Password'){
                    setPasswordIsInvalid(true);
                    setErrorPassword(errorMessage);
                  }
            });
        });
        }

    } catch (error) {
      console.error('Wystąpił błąd');
    }
  };

  const getInputClassName = (field) => {
    if (isSuccessful) {
        return field === 'email' || field === 'password' || field === 'name' || field === 'surname' || field === 'confirmPassword' ? 'form-control is-valid' : 'form-control';
    }
    if(emailIsInvalid && field === 'email'){
        return 'form-control is-invalid';
    }
    if(confirmPasswordIsInvalid && (field === 'password' || field === 'confirmPassword')){
        return 'form-control is-invalid';
    }
    if(passwordIsInvalid && field === 'password'){
        return 'form-control is-invalid';
    }
    return 'form-control';
  };

  return (
    <div className="row justify-content-center top-50 start-50 position-absolute translate-middle">
      <div className='text-center col-lg-7'>
        <i className="fa-solid fa-user-plus fa-beat-fade"></i>
        <p className="mb-5 fs-2">Rejestracja użytkownika</p>
        <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
            Pomyślnie utworzono konto <a href="/login" class="alert-link">Zaloguj się</a>.
        </div>
        <form onSubmit={handleSubmit}>
          <div className="row">
            <div className="col-lg-6 col-md-6 mb-4">
              <div className="form-floating">
                <input type="text" className={getInputClassName('name')} id="floatingInputGridName" placeholder="" value={name} onChange={(e) => setName(e.target.value)}/>
                <label>Imię</label>
              </div>
            </div>
            <div className="col-lg-6 col-md-6 mb-4">
              <div className="form-floating">
                <input type="text" className={getInputClassName('surname')} id="floatingInputGridSurname" placeholder="" value={surname} onChange={(e) => setSurname(e.target.value)}/>
                <label>Nazwisko</label>
              </div>
            </div>
            <div className="mb-4">
              <div className="form-floating">
                <input type="email" className={getInputClassName('email')} id="floatingInputGridEmail" placeholder="" value={email} onChange={(e) => setEmail(e.target.value)}/>
                <label>Adres email</label>
                <div className='invalid-feedback'>{errorEmail}</div>
              </div>
            </div>
            <div className="mb-4">
              <div className="form-floating">
                <input type="password" className={getInputClassName('password')} id="floatingInputGridPassword" placeholder="" value={password} onChange={(e) => setPassword(e.target.value)}/>
                <label>Hasło</label>
                <div className='invalid-feedback'>{errorPassword}</div>
              </div>
            </div>
            <div className="mb-4">
              <div className="form-floating">
                <input type="password" className={getInputClassName('confirmPassword')} id="floatingInputGridConfirmPassword" placeholder="" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)}/>
                <label>Powtórz hasło</label>
                <div className='invalid-feedback'>{errorConfirmPassword}</div>
              </div>
            </div>
            <div className="mb-4">
                <div class="form-check form-check-inline">
                    <input className="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value={1} onChange={(e) => setRoleId(1)} checked />
                    <label className="form-check-label" htmlFor="inlineRadio1">Tancerz</label>
                </div>
                <div class="form-check form-check-inline">
                    <input className="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value={2} onChange={(e) => setRoleId(2)} />
                    <label className="form-check-label" htmlFor="inlineRadio2">Trener</label>
                </div>
            </div>
          </div>
            <button className="btn btn-outline-primary mb-4" type="submit">Zarejestruj</button>
            <div class="text-center">
              <p>Masz już konto? <a href="/login">Zaloguj się!</a></p>
            </div>
        </form>
      </div>
    </div>
  );
}

Signup.propTypes = {
  setToken: PropTypes.func.isRequired
}