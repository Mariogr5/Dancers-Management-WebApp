import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Navbar from '../Navbar/Navbar';
import './EventAdd.css';
import useToken from '../useToken';

export default function EventAdd() {
    const [name, setName] = useState(null);
    const [description, setDescription] = useState(null);
    const [organizer, setOrganizer] = useState(null);
    const [city, setCity] = useState(null);
    const [emailAdress, setEmailAdress] = useState(null);
    const [date, setDate] = useState(null);
    const [competition, setCompetition] = useState(null);
    const [isSuccessful, setIsSuccessful] = useState(false);

    const { token } = useToken();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setCompetition(true);

        try {
            const response = await fetch('https://localhost:7234/danceevent', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, description, competition, organizer, city, emailAdress, date }),
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
                    <i class="fa-solid fa-calendar-plus fa-beat-fade"></i>
                    <p className="mb-5 fs-2">Nowe wydarzenie</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie utworzono wydarzenie, <a href="/" class="alert-link">Lista wydarzeń</a>.
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridName" placeholder="" value={name} onChange={(e) => setName(e.target.value)} />
                                    <label>Nazwa wydarzenia</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="col-lg-6 col-md-6 mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridOrganizer" placeholder="" value={organizer} onChange={(e) => setOrganizer(e.target.value)} />
                                    <label>Organizator</label>
                                </div>
                            </div>
                            <div className="col-lg-6 col-md-6 mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridCity" placeholder="" value={city} onChange={(e) => setCity(e.target.value)} />
                                    <label>Misto</label>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="email" className='form-control' id="floatingInputGridEmail" placeholder="" value={emailAdress} onChange={(e) => setEmailAdress(e.target.value)} />
                                    <label>Adres email</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="datetime-local" className='form-control' id="floatingInputGridDate" placeholder=""  value={date} onChange={(e) => setDate(e.target.value)} />
                                    <label>Data</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <label for="exampleFormControlTextarea1" class="form-label">Opis</label>
                                <div className="form-floating">
                                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" value={description} onChange={(e) => setDescription(e.target.value)} ></textarea>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                        </div>
                        <button className="btn btn-outline-primary mb-4" type="submit">Utwórz</button>
                        <div class="text-center">
                            <p>Zrezygnuj: <a href="/">Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}