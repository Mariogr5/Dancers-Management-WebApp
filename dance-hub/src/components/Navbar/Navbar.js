import React from 'react';
import useToken from '../useToken';
import { Link, useLocation } from 'react-router-dom';
import './Navbar.css';

export default function Navbar() {
    const { token, logout } = useToken();

    const location = useLocation();

    const navItems = [
        { to: '/dashboard', label: 'Wydarzenia' },
        { to: '/dancers', label: 'Tancerze' },
        { to: '/clubs', label: 'Kluby' },
    ];

    if (token) {
        return (
            <nav class="navbar bg-body-tertiary fixed-top">
                <div class="container-fluid">
                    <div className='navbar-expand-lg'>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarText">
                            <ul class="navbar-nav me-auto mb-2 mb-lg-0 ml-8">
                                <li class="nav-item">
                                    <a class="nav-link" href="/">DanceHub</a>
                                </li>
                                {navItems.map((item, index) => (
                                    <li className='nav-item' key={index}>
                                        <Link className={`nav-link ${location.pathname === item.to ? 'active' : ''}`} to={item.to}>
                                            {item.label}
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>
                    <button class="navbar-toggler btn btn-outline-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar" aria-label="Toggle navigation">
                        <span class="navrab-user-icon"><i class="fa-regular fa-user"></i></span>
                    </button>
                    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasNavbarLabel"><i class="fa-regular fa-user"></i> Profil użytkownika</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                                <li class="nav-item">
                                    <p class="nav-link active">Imie: </p>
                                </li>
                                <li class="nav-item">
                                    <p class="nav-link active">Nazwisko: </p>
                                </li>
                                <li class="nav-item">
                                    <p class="nav-link active">Adres Email: </p>
                                </li>
                            </ul>
                            <button class="btn btn-outline-primary m-2" type="submit">Ustawienia</button>
                            <button class="btn btn-outline-danger" type="submit" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar" aria-label="Toggle navigation" onClick={() => { logout(); }}>Wyloguj</button>
                        </div>
                    </div>
                </div>
            </nav>
        );
    } else {
        return (
            <nav class="navbar bg-body-tertiary fixed-top">
                <div class="container-fluid">
                    <div className='navbar-expand-lg'>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarText">
                            <ul class="navbar-nav me-auto mb-2 mb-lg-0 ml-8">
                                <li class="nav-item">
                                    <a class="nav-link" href="/">DanceHub</a>
                                </li>
                                {navItems.map((item, index) => (
                                    <li className='nav-item' key={index}>
                                        <Link className={`nav-link ${location.pathname === item.to ? 'active' : ''}`} to={item.to}>
                                            {item.label}
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>
                    <a href='/login'><button class="btn btn-outline-primary" type="button">Zaloguj się</button></a>
                </div>
            </nav>
        );
    }
}