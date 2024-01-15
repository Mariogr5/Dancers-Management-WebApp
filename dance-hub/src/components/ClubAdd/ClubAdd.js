import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './ClubAdd.css';
import useToken from '../useToken';

export default function EventAdd() {
    const [name, setName] = useState(null);
    const [owner, setOwner] = useState(null);
    const [city, setCity] = useState(null);
    const [street, setStreet] = useState(null);
    const [postalCode, setPostalCode] = useState(null);
    const [isSuccessful, setIsSuccessful] = useState(false);

    const { token } = useToken();

    const handlePostalCodeChange = (e) => {
        let inputValue = e.target.value.replace(/\D/g, ''); // Usuń wszystkie niecyfrowe znaki

        // Formatuj kod pocztowy jako "XX-XXX"
        if (inputValue.length > 2) {
            inputValue = `${inputValue.slice(0, 2)}-${inputValue.slice(2, 5)}`;
        }

        setPostalCode(inputValue);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('https://localhost:7234/danceclub', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Accept': '*/*',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, owner, city, street, postalCode }),
            });

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

            <div className="row justify-content-center top-50 start-50 position-absolute translate-middle">
                <div className='text-center col-lg-7'>
                    <i class="fa-solid fa-circle-nodes fa-beat-fade"></i>
                    <p className="mb-5 fs-2">Nowy klub</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie utworzono klub, <a href="/clubs" class="alert-link">Lista klubów tanecznych</a>.
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridName" placeholder="" value={name} onChange={(e) => setName(e.target.value)} />
                                    <label>Nazwa klubu</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="test" className='form-control' id="floatingInputGridEmail" placeholder="" value={owner} onChange={(e) => setOwner(e.target.value)} />
                                    <label>Właściciel</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="col-lg-6 col-md-6 mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridOrganizer" placeholder="" value={postalCode} onChange={handlePostalCodeChange} />
                                    <label>Kod pocztowy</label>
                                </div>
                            </div>
                            <div className="col-lg-6 col-md-6 mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridCity" placeholder="" value={city} onChange={(e) => setCity(e.target.value)} />
                                    <label>Miasto</label>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridName" placeholder="" value={street} onChange={(e) => setStreet(e.target.value)} />
                                    <label>Ulica</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                        </div>
                        <button className="btn btn-outline-primary mb-4" type="submit">Stwórz</button>
                        <div class="text-center">
                            <p>Zrezygnuj: <a href="/clubs">Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}