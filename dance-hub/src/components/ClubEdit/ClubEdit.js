import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './ClubEdit.css';
import useToken from '../useToken';
import { useParams } from 'react-router-dom';

export default function EventAdd() {
    const { id } = useParams();
    const [name, setName] = useState(null);
    const [owner, setOwner] = useState(null);
    const [isSuccessful, setIsSuccessful] = useState(false);

    const { token } = useToken();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`https://localhost:7234/danceclub/${id}`, {
                method: 'PUT',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Accept': '*/*',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, owner }),
            });

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
                    <p className="mb-5 fs-2">Edytujesz klub #{id}</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie edytowano klub, <a href="/clubs" class="alert-link">Lista klubów tanecznych</a>.
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
                        </div>
                        <button className="btn btn-outline-primary mb-4" type="submit">Edytuj</button>
                        <div class="text-center">
                            <p>Zrezygnuj: <a href="/clubs">Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}