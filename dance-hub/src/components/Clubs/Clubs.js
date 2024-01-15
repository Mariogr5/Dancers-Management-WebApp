import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar'
import './Clubs.css';
import useToken from '../useToken';

export default function Clubs() {
    const [clubs, setClubs] = useState([]);
    const [clubId, setClubId] = useState(null);
    const { token } = useToken();

    useEffect(() => {
        fetch('https://localhost:7234/danceclub')
            .then(response => response.json())
            .then(data => setClubs(data));
    }, []);

    const handleDeleteClubClick = (clubId) => {
        setClubId(clubId);
    };

    const handleDeleteClub = () => {
        fetch(`https://localhost:7234/danceclub/${clubId}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = `/clubs`;
                } else {
                    console.error('Error deleting event:', response.status, response.statusText);
                    return response.json();
                }
            })
            .then(errorData => {
                if (errorData) {
                    console.error('Additional error details:', errorData);
                }
            })
            .catch(error => console.error('Fetch error:', error));
    };

    return (
        <div>
            <Navbar />
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-solid fa-users"></i> Kluby</h2>
                </div>
            </div>
            <div className='d-flex justify-content-center mt-5'>
                <div className='col-lg-8 col-md-10 col-sm-11 col-11 text-left'>
                    <table class="table table-primary table-striped table-hover table-borderless">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Nazwa</th>
                                <th scope="col">Właściciel</th>
                                <th scope="col">Adres</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody className='table-group-divider'>
                            {clubs.map(club => (
                                <tr key={club.id}>
                                    <td>{club.id}</td>
                                    <td>{club.name}</td>
                                    <td>{club.owner}</td>
                                    <td>{club.postalCode}, {club.city}<br />{club.street}</td>
                                    <td>
                                        <div class="container text-center">
                                            <div class="row justify-content-md-end">
                                                <div class="col-md-auto">
                                                    <a class="nav-link" href={`/clubEdit/${club.id}`}><i class="fa-solid fa-pen-to-square"></i></a>
                                                </div>
                                                <div class="col-md-auto">
                                                    <a class="nav-link" href={`/club/${club.id}`}><i class="fa-solid fa-address-book"></i></a>
                                                </div>
                                                <div class="col-md-auto">
                                                    <i class="fa-solid fa-trash-can pointer" data-bs-toggle="modal" data-bs-target="#deleteClub" onClick={() => handleDeleteClubClick(club.id)}></i>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <div className='text-center'>
                {token && (
                    <div>
                        <a href={`/clubAdd`} className="btn btn-primary mt-2 mb-2">Stwórz klub</a>
                    </div>
                )}
            </div>
            <div class="modal fade" id="deleteClub" tabindex="-1" aria-labelledby="deleteClubLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="deleteClubLabel">Usuwanie klubu</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Czy chcesz usunąc klub #{clubId}?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                            <button type="button" class="btn btn-danger" onClick={() => handleDeleteClub()}>Usuń</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}