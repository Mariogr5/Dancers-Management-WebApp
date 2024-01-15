import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './Dancers.css';
import useToken from '../useToken';

export default function Dancers() {
    const [dancers, setDancers] = useState([]);
    const [clubs, setClubs] = useState([]);
    const [clubClass, setClubClass] = useState([]);
    const [clubName, setClubName] = useState([]);
    const { token } = useToken();

    useEffect(() => {
        fetch('https://localhost:7234/dancer')
            .then(response => response.json())
            .then(data => setDancers(data));
    }, []);

    useEffect(() => {
        fetch('https://localhost:7234/danceclub')
            .then(response => response.json())
            .then(data => setClubs(data));
    }, []);

    const handleClassClick = (clubClass) => {
        setClubClass(clubClass);
        fetch(`https://localhost:7234/dancer/danceclass/${clubClass}`, {
            method: 'GET',
            headers: {
                'Accept': '*/*',
            },
        })
        .then(response => response.json())
        .then(data => setDancers(data));
    };

    const handleClubClick = (clubName) => {
        setClubName(clubName);
        fetch(`https://localhost:7234/dancer/danceclub/${clubName}`, {
            method: 'GET',
            headers: {
                'Accept': '*/*',
            },
        })
        .then(response => response.json())
        .then(data => setDancers(data));
    };

    return (
        <div>
            <Navbar />
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-regular fa-rectangle-list"></i> Lista tancerzy</h2>
                </div>
            </div>
            <div className='d-flex justify-content-center mt-3'>
                <div class="accordion col-lg-8 col-md-10 col-sm-11 col-11" id="accordionExample">
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                Filtry wyszukiwania
                            </button>
                        </h2>
                        <div id="collapseOne" class="accordion-collapse collapse" data-bs-parent="#accordionExample">
                            <div class="accordion-body">
                                <div class="container text-center">
                                    <div class="row justify-content-md-center">
                                        {clubs ? (
                                            <div class="col-md-auto p-5">
                                                <h4>Kluby</h4>
                                                {clubs.map(club => (
                                                    <div class="form-check">
                                                        <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value={club.id} onClick={(e) => handleClubClick(e.target.value)} />
                                                        <label class="form-check-label" for="flexRadioDefault2">
                                                            {club.name}
                                                        </label>
                                                    </div>
                                                ))
                                                }
                                            </div>
                                        ) : (
                                            <p>Loading event details...</p>
                                        )}
                                        <div class="col-md-auto p-5">
                                            <h4>Klasy</h4>

                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="A" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">A</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="B" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">B</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="C" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">C</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="D" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">D</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="E" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">E</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="S" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">S</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="F" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">F</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="H" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">H</label>
                                            </div>
                                            <div class="form-check">
                                                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="G" onClick={(e) => handleClassClick(e.target.value)} />
                                                <label class="form-check-label" for="flexRadioDefault2">G</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                                <th scope="col">Klasa</th>
                                <th scope="col">Klub</th>
                                <th scope="col">Punkty</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody className='table-group-divider'>
                            {dancers.map(dancer => (
                                <tr key={dancer.id}>
                                    <td>{dancer.id}</td>
                                    <td>{dancer.name}</td>
                                    <td>{dancer.danceclass}</td>
                                    <td>{dancer.danceClubName}</td>
                                    <td>{dancer.numberofPoints}</td>
                                    <td><a class="nav-link" href={`/dancer/${dancer.id}`}><i class="fa-solid fa-arrow-up-right-from-square"></i></a></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <div className='text-center'>
                {token && (
                    <div>
                        <a href={`/dancerAdd`} className="btn btn-primary mt-2 mb-2">Utwórz tancerza</a>
                    </div>
                )}
            </div>
        </div>
    );
}
