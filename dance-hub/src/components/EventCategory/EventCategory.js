import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Navbar from '../Navbar/Navbar';
import './EventCategory.css';

export default function EventAdd() {
    const { id } = useParams();
    const [ageRange, setAgeRange] = useState(null);
    const [categoryDanceClass, setCategoryDanceClass] = useState(null);
    const [isSuccessful, setIsSuccessful] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch(`https://localhost:7234/danceevent/category/${id}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ ageRange, categoryDanceClass }),
            }, [id]);

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

    const handleInputChange = (e) => {
        // Usuń wszystkie niecyfrowe znaki
        const input = e.target.value.replace(/\D/g, '');

        // Sprawdź, czy wprowadzono więcej niż 2 cyfry
        if (input.length > 2) {
            // Dodaj myślnik po trzeciej cyfrze
            const formattedInput = `${input.slice(0, 2)}-${input.slice(2)}`;
            setAgeRange(formattedInput);
        } else {
            setAgeRange(input);
        }
    };

    return (
        <div>
            <Navbar />

            <div className="row justify-content-center top-50 start-50 position-absolute translate-middle">
                <div className='text-center col-lg-7'>
                    <i class="fa-solid fa-calendar-plus fa-beat-fade"></i>
                    <p className="mb-5 fs-2">Utwórz kategorię</p>
                    <div class="alert alert-success" role="alert" hidden={!isSuccessful}>
                        Pomyślnie utworzono kategorię. <a href={`/event/${id}`} class="alert-link">Powrót do wydarzenia</a>.
                    </div>
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="mb-4">
                                <div className="form-floating">
                                    <input type="text" className='form-control' id="floatingInputGridAge" placeholder="" value={ageRange} onChange={handleInputChange} />
                                    <label>Zakres wiekowy</label>
                                    <div className='invalid-feedback'></div>
                                </div>
                            </div>
                            <div className="mb-4">
                                <select class="form-select" multiple aria-label="Multiple select example" onChange={(e) => setCategoryDanceClass(e.target.value)}>
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
                        <button className="btn btn-outline-primary mb-4" type="submit">Utwórz</button>
                        <div class="text-center">
                            <p>Zrezygnuj: <a href={`/event/${id}`}>Cofnij</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}