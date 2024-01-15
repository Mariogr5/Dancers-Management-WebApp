import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './Dancer.css';
import useToken from '../useToken';
import { useParams } from 'react-router-dom';

export default function Dancers() {
    const { id } = useParams();
    const { token } = useToken();
    const [dancer, setDancer] = useState([]);
    const [club, setClub] = useState('');
    const [danceClubId, setDanceClubId] = useState('');

    useEffect(() => {
        fetch(`https://localhost:7234/dancer/${id}`)
            .then(response => response.json())
            .then(data => setDancer(data))
            .catch(error => console.error('Error fetching event details:', error));
    }, [id]);

    useEffect(() => {
        fetch(`https://localhost:7234/danceclub`)
            .then(response => response.json())
            .then(data => setClub(data))
            .catch(error => console.error('Error fetching event details:', error));
    });

    const handleDeleteDancer = () => {
        fetch(`https://localhost:7234/dancer/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        }, [id])
            .then(response => {
                if (response.ok) {
                    window.location.href = `/dancers`;
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

    const handleEditClub = () => {
        fetch(`https://localhost:7234/dancer/${id}/newclub/${danceClubId}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json'
            },
        }, [id], [danceClubId])
            .then(response => {
                if (response.ok) {
                    window.location.href = `/dancer/${id}`;
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
            <div className='mt-100'>
                {dancer ? (
                    <div className="row justify-content-center">
                        <div className="col-sm-6 mb-3 mb-sm-0">
                            <div className="card">
                                <div className="card-header text-center text-bg-primary">
                                    <h5 className="card-title">{dancer.name}</h5>
                                </div>
                                <div className="card-body">
                                    <div className="container">
                                        <div className="row row-cols-2">
                                            <div className='col text-start mb-2'>Id:</div>
                                            <div className='col text-end mb-2'>{dancer.id}</div>
                                            <div className='col text-start mb-2'>Klasa:</div>
                                            <div className='col text-end mb-2'>{dancer.danceclass}</div>
                                            <div className='col text-start mb-2'>Partner:</div>
                                            <div className='col text-end mb-2'>{dancer.dancePartnerName}</div>
                                            <div className='col text-start mb-2'>Klub:</div>
                                            <div className='col text-end mb-2'>{dancer.danceClubName}</div>
                                            <div className='col text-start mb-2'>Numer kontaktowy:</div>
                                            <div className='col text-end mb-2'>{dancer.contactNumber}</div>
                                            <div className='col text-start mb-2'>Punkty:</div>
                                            <div className='col text-end mb-2'>{dancer.numberofPoints}</div>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div className='text-center'>
                                    <a href="/dancers" class="btn btn-primary">Powrót</a>

                                    {token && (
                                        <div>
                                            <div>
                                                <a className="btn btn-success mt-2" data-bs-toggle="modal" data-bs-target="#editClub">Zmień klub</a>
                                            </div>
                                            <div>
                                                <a className="btn btn-danger mt-2 mb-2" data-bs-toggle="modal" data-bs-target="#deleteDancer">Usuń tańcerza</a>
                                            </div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <p>Loading event details...</p>
                )}
            </div>
            <div class="modal fade" id="deleteDancer" tabindex="-1" aria-labelledby="deleteDancerLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="deleteDancerLabel">Usuwanie tańcerza</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Czy chcesz usunąc tancerza #{id}?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                            <button type="button" class="btn btn-danger" onClick={() => handleDeleteDancer()}>Usuń</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="editClub" tabindex="-1" aria-labelledby="editClubLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="editClubLabel">Zmiana klubu</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={handleEditClub}>
                            <div class="modal-body">
                                <div className="row">
                                    <div className="mb-4">
                                        <div className="form-floating">
                                            {club ? (
                                                <select class="form-select" aria-label="Default select example" onClick={(e) => setDanceClubId(e.target.value)}>
                                                    {club.map(c => (
                                                        <option key={c.id} value={c.id}>{c.name}</option>
                                                    ))}
                                                </select>
                                            ) : (
                                                <p>Loading event details...</p>
                                            )}
                                            <label>Klub</label>
                                            <div className='invalid-feedback'></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                                <button type="submit" class="btn btn-success">Zapisz</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}