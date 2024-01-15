import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './DancerAdd.css';
import useToken from '../useToken';

export default function EventAdd() {
    const [danceClubId, setDanceClubId] = useState('');
    const [name, setName] = useState('');
    const [danceclass, setDanceclass] = useState('');
    const [numberofPoints, setNumberofPoints] = useState('');
    const [contactNumber, setContactNumber] = useState('');
    const [contactEmail, setContactEmail] = useState('');
    const [isSuccessful, setIsSuccessful] = useState(false);
    const [club, setClub] = useState('');

    const { token } = useToken();

    useEffect(() => {
        fetch(`https://localhost:7234/danceclub`)
            .then(response => response.json())
            .then(data => setClub(data))
            .catch(error => console.error('Error fetching event details:', error));
    });

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch(`https://localhost:7234/dancer/danceclub/${danceClubId}`, {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Accept': '*/*',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ name, danceclass, numberofPoints, contactNumber, contactEmail, danceClubId }),
            }, [danceClubId]);

            console.log(response)

            if (response.ok) {
                setIsSuccessful(true);
            } else {
                let data = await response.json();
                data = data.errors;
                const errorKeys = Object.keys(data);
                setIsSuccessful(false);

                errorKeys.forEach((errorKey) => {
                    data[errorKey].forEach((errorMessage) => {
                        console.log(errorMessage);
                        console.log(errorKey);
                    });
                });
            }

        } catch (error) {
            console.error('Wystąpił błąd');
        }
    };

    return (
        <div>
            <Navbar />

            <div className="row justify-content-center top-50 start-50 position-absolute translate-middle mt-50">
                <div className='text-center col-lg-7'>
                    <i class="fa-solid fa-person-circle-plus fa-beat-fade"></i>
                    <p className="mb-5 fs-2">Nowy tancerz</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie utworzono tancerza, <a href="/dancers" class="alert-link">Lista tancerzy</a>.
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="mb-4">
                                <div className="form-floating">
                                    {club ? (
                                        <select class="form-select" aria-label="Default select example" onClick={(e) => setDanceClubId(e.target.value)}>
                                        { club.map(c => (
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
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridName" placeholder="" value={name} onChange={(e) => setName(e.target.value)} />
                                    <label>Imię i nazwisko</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="mb-4">
                                    <label>Klasa</label>
                                    <select class="form-select" multiple aria-label="Multiple select example" onClick={(e) => setDanceclass(e.target.value)}>
                                        <option selected value="A">A</option>
                                        <option value="B">B</option>
                                        <option value="C">C</option>
                                        <option value="D">D</option>
                                        <option value="E">E</option>
                                        <option value="S">S</option>
                                        <option value="F">F</option>
                                        <option value="H">H</option>
                                        <option value="G">G</option>
                                    </select>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="number" className='form-control' id="floatingInputGridNumberofPoints" placeholder="" value={numberofPoints} onChange={(e) => setNumberofPoints(e.target.value)} />
                                    <label>Ilość punktów</label>
                                </div>
                            </div>

                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="email" className='form-control' id="floatingInputGridEmail" placeholder="" value={contactEmail} onChange={(e) => setContactEmail(e.target.value)} />
                                    <label>Adres email</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridDate" placeholder="" value={contactNumber} onChange={(e) => setContactNumber(e.target.value)} />
                                    <label>Numer kontaktowy</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                        </div>
                        <button className="btn btn-outline-primary mb-4" type="submit">Utwórz</button>
                        <div class="text-center">
                            <p>Zrezygnuj: <a href="/dancers">Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}