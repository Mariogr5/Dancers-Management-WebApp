import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './Pairs.css';
import useToken from '../useToken';

export default function Dancers() {
    const [pairs, setPairs] = useState([]);
    const [pairId, setPairId] = useState(null);
    const { token } = useToken();

    useEffect(() => {
        fetch('https://localhost:7234/dancepair')
            .then(response => response.json())
            .then(data => setPairs(data));
    }, []);

    const handleDeletePairClick = (pairId) => {
        setPairId(pairId);
    };

    const handleDeletePair = () => {
        fetch(`https://localhost:7234/dancepair/${pairId}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = `/pairs`;
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
            <Navbar/>
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-solid fa-person-half-dress"></i> Pary</h2>
                </div>
            </div>
            <div className='d-flex justify-content-center mt-5'>
                <div className='col-lg-8 col-md-10 col-sm-11 col-11 text-left'>
                    <table class="table table-primary table-striped table-hover table-borderless">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Tancerz</th>
                                <th scope="col">Partner</th>
                                <th scope="col">Klub</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody className='table-group-divider'>
                            {pairs.map(pair => (
                                <tr key={pair.id}>
                                    <td>{pair.id}</td>
                                    <td><a href={`/dancer/${pair.dancerId}`} className='pairlink'>{pair.dancerName}</a></td>
                                    <td><a href={`/dancer/${pair.dancePartnerId}`} className='pairlink'>{pair.dancePartnerName}</a></td>
                                    <td>{pair.dancePairClubName}</td>
                                    <td><i class="fa-solid fa-trash-can pointer" data-bs-toggle="modal" data-bs-target="#deletePair" onClick={() => handleDeletePairClick(pair.id)}></i></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <div className='text-center'>
            {token && (
                <div>
                    <a href={`/pairAdd`} className="btn btn-primary mt-2 mb-2">Utwórz parę</a>
                </div>
            )}
            </div>
            <div class="modal fade" id="deletePair" tabindex="-1" aria-labelledby="deletePairLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="deletePairLabel">Usuwanie pary</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Czy chcesz usunąc parę #{pairId}?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                            <button type="button" class="btn btn-danger" onClick={() => handleDeletePair()}>Usuń</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
