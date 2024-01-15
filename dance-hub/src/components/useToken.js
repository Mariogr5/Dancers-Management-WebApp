import { useState, useEffect } from 'react';

const FIVE_DAYS_IN_MS = 5 * 24 * 60 * 60 * 1000; // 5 dni w milisekundach

export default function useToken() {
  const getToken = () => {
    const userToken = localStorage.getItem('token');
    return userToken;
  };

  const [token, setToken] = useState(getToken());
  const [lastActivity, setLastActivity] = useState(new Date());
  let autoLogoutTimer;

  // Funkcja do automatycznego wylogowania
  const startAutoLogout = () => {
    setTimeout(() => {
      logout();
    }, FIVE_DAYS_IN_MS);
  };

  const stopAutoLogout = () => {
    clearTimeout(autoLogoutTimer);
  };

  // Funkcja do aktualizacji daty ostatniej aktywności
  const updateLastActivity = () => {
    setLastActivity(new Date());
    stopAutoLogout();
    startAutoLogout();
  };

  const saveToken = userToken => {
    localStorage.setItem('token', userToken);
    setToken(userToken);
    updateLastActivity();
    startAutoLogout();
  };

  const logout = () => {
    localStorage.removeItem('token');
    setToken(null);
    stopAutoLogout();
    window.location.href = `/`;
  };

  useEffect(() => {
    updateLastActivity();
  }, []);

  return {
    token,
    setToken: saveToken,
    logout,
  };
}