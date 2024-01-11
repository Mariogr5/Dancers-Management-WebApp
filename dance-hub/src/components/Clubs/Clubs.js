import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar'
import './Clubs.css'

export default function Clubs() {
    const [clubs, setClubs] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7234/danceclub')
            .then(response => response.json())
            .then(data => setClubs(data));
    }, []);

    console.log(clubs);

    return (
        <div>
            <Navbar/>
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-solid fa-users"></i> Kluby</h2>
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
                                    <td>{club.postalCode}, {club.city}<br/>{club.street}</td>
                                    <td><a class="nav-link" href={`/club/${club.id}`}><i class="fa-solid fa-address-book"></i></a></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}