import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Navbar from '../Navbar/Navbar'
import './ClubDetails.css'
import useToken from '../useToken';

export default function ClubDetails() {
    const { id } = useParams();
    const { token } = useToken();
    const [club, setClub] = useState([]);

    useEffect(() => {
        fetch(`https://localhost:7234/danceclub/${id}`)
            .then(response => response.json())
            .then(data => setClub(data))
            .catch(error => console.error('Error fetching event details:', error));
    }, [id]);

    console.log(id);
    console.log(club);

    return (
        <div>
            <Navbar />
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-solid fa-users"></i> Tancerze w klubie <strong>{club.name}</strong></h2>
                </div>
            </div>
            <div className='d-flex justify-content-center mt-3'>
                <div class="accordion col-lg-8 col-md-10 col-sm-11 col-11" id="accordionExample">
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                Filtr wyszukiwania
                            </button>
                        </h2>
                        <div id="collapseOne" class="accordion-collapse collapse" data-bs-parent="#accordionExample">
                            <div class="accordion-body">
                                <p>filtry</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className='d-flex justify-content-center mt-5'>
                <div className='col-lg-8 col-md-10 col-sm-11 col-11 text-left'>
                    <table class="table table-primary table-striped table-hover table-borderless">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Imię i Nazwisko</th>
                                <th scope="col">Punkty</th>
                                <th scope="col">Klasa</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody className='table-group-divider'>
                            {club.dancers && club.dancers.length > 0 && (
                                club.dancers.map((dancer, index) => (
                                    <tr key={index}>
                                        <td>{dancer.id}</td>
                                        <td>{dancer.name}</td>
                                        <td>{dancer.numberofPoints}</td>
                                        <td>{dancer.danceclass}</td>
                                        <td><a class="nav-link" href={`/dancer/${dancer.id}`}><i class="fa-solid fa-arrow-up-right-from-square"></i></a></td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}