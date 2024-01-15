import React, { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import './PairAdd.css';
import useToken from '../useToken';

export default function EventAdd() {
    const [dancerId, setDancerId] = useState('');
    const [partnerId, setPartnerId] = useState('');
    const [error, setError] = useState(false);
    const [errorMsg] = useState('Nie można utworzyć pary jednoosobowej/Wybrano te same osoby!');
    const [isSuccessful, setIsSuccessful] = useState(false);
    const [dancers, setDancers] = useState('');
    const [pairNumberofPoints, setPairNumberofPoints] = useState('');
    const [pairDanceClass, setPairDanceClass] = useState('');

    const { token } = useToken();

    useEffect(() => {
        fetch(`https://localhost:7234/dancer`)
            .then(response => response.json())
            .then(data => setDancers(data))
            .catch(error => console.error('Error fetching event details:', error));
    });

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (dancerId !== partnerId) {
            setError(false);
            try {
                const response = await fetch(`https://localhost:7234/dancepair/${dancerId}/partner/${partnerId}`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${token}`,
                        'Accept': '*/*',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ pairDanceClass, pairNumberofPoints}),
                }, []);

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
        }else{
            setError(true);
        }
    };

    const getInputClassName = (field) => {
        if (isSuccessful) {
            return field === 'partner' ? 'form-select is-valid' : 'form-control';
        }
        if (error) {
            return 'form-control is-invalid';
        }
        else{
            return 'form-select';
        }
      };

    return (
        <div>
            <Navbar />

            <div className="row justify-content-center top-50 start-50 position-absolute translate-middle mt-50">
                <div className='text-center col-lg-7'>
                    <i class="fa-solid fa-person-circle-plus fa-beat-fade"></i>
                    <p className="mb-5 fs-2">Utwórz parę</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie utworzono parę, <a href="/pairs" class="alert-link">Lista par</a>.
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="mb-4">
                                <div className="form-floating">
                                    {dancers ? (
                                        <select className={getInputClassName('partner')} aria-label="Default select example" onClick={(e) => setDancerId(e.target.value)}>
                                            {dancers.map(dancer => (
                                                <option key={dancer.id} value={dancer.id}>{dancer.name}</option>
                                            ))}
                                        </select>
                                    ) : (
                                        <p>Loading event details...</p>
                                    )}
                                    <label>Tancerz</label>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    {dancers ? (
                                        <select className={getInputClassName('partner')} aria-label="Default select example" onClick={(e) => setPartnerId(e.target.value)}>
                                            {dancers.map(dancer => (
                                                <option key={dancer.id} value={dancer.id}>{dancer.name}</option>
                                            ))}
                                        </select>
                                    ) : (
                                        <p>Loading event details...</p>
                                    )}
                                    <label>Partner</label>
                                    <div className='invalid-feedback'>{errorMsg}</div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="mb-4">
                                    <label>Klasa</label>
                                    <select class="form-select" multiple aria-label="Multiple select example" onClick={(e) => setPairDanceClass(e.target.value)}>
                                        <option selected>A</option>
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
                                    <input type="number" className='form-control' id="floatingInputGridName" placeholder="" value={pairNumberofPoints} onChange={(e) => setPairNumberofPoints(e.target.value)} />
                                    <label>Punkty</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                        </div>
                        <button className="btn btn-outline-primary mb-4" type="submit">Utwórz</button>
                        <div className="text-center">
                            <p>Zrezygnuj: <a href="/pairs">Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}