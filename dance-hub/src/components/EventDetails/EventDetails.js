import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Navbar from '../Navbar/Navbar';
import useToken from '../useToken';
import format from 'date-fns/format';
import './EventDetails.css'

export default function EventDetail() {
    const { id } = useParams();
    const [event, setEvent] = useState(null);
    const [pairs, setPairs] = useState([]);
    const [pairId, setPairId] = useState(null);
    const { token } = useToken();
    const [categoryId, setCategoryId] = useState(null);
    const [categoryIdAdd, setCategoryIdAdd] = useState(null);

    useEffect(() => {
        fetch(`https://localhost:7234/DanceEvent/${id}`)
            .then(response => response.json())
            .then(data => setEvent(data))
            .catch(error => console.error('Error fetching event details:', error));
    }, [id]);

    useEffect(() => {
        fetch(`https://localhost:7234/dancepair`)
            .then(response => response.json())
            .then(data => setPairs(data))
            .catch(error => console.error('Error fetching event details:', error));
    });

    const formattedDate = (dateString) => {
        const date = new Date(dateString);
        return format(date, 'dd.MM.yyyy');
    };

    const formattedTime = (dateString) => {
        const date = new Date(dateString);
        return format(date, 'HH:mm');
    };

    const handleDeleteCategoryClick = (categoryId) => {
        setCategoryId(categoryId);
    };

    const handleDeleteCategory = () => {
        fetch(`https://localhost:7234/danceevent/category/${categoryId}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = `/event/${id}`;
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

    const handleAddCompetitionPair = () => {
        console.log(pairId);
        console.log(categoryIdAdd);

        fetch(`https://localhost:7234/dancepair/${pairId}/competition/${categoryIdAdd}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = `/event/${id}`;
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
            <Navbar />
            <div className='mt-100'>
                {event ? (
                    <div class="row justify-content-center">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <div class="card">
                                <div class="card-header text-center text-bg-primary">
                                    <h5 class="card-title">{event.name}</h5>
                                </div>
                                <div class="card-body">
                                    <div class="container">
                                        <div class="row row-cols-2">
                                            <div className='col text-start mb-2'>Data:</div>
                                            <div className='col text-end mb-2'>{formattedDate(event.date)}</div>
                                            <div className='col text-start mb-2'>Godzina:</div>
                                            <div className='col text-end mb-2'>{formattedTime(event.date)}</div>
                                            <div className='col text-start mb-2'>Organizator:</div>
                                            <div className='col text-end mb-2'>{event.organizer}</div>
                                            <div className='col text-start mb-2'>Miasto:</div>
                                            <div className='col text-end mb-2'>{event.city}</div>
                                            <div className='col text-start mb-2'>Kontakt:</div>
                                            <div className='col text-end mb-2'>{event.emailAdress}</div>
                                            <div className='col text-start mb-2'>Opis:</div>
                                            <div className='col text-end mb-2'>{event.description}</div>
                                        </div>
                                        <hr />
                                    </div>
                                    <h5 class="card-title text-center mb-3">Kategorie wydarzenia</h5>
                                    <div class="container">
                                        {event.danceCompetitionCategories.map((category, index) => (
                                            <div>
                                                <div class="row row-cols-2" key={index}>
                                                    <div className='col text-start mb-2'>Numer:</div>
                                                    <div className='col text-end mb-2'>{category.id} <i class="fa-solid fa-trash-can pointer" data-bs-toggle="modal" data-bs-target="#deleteCategory" onClick={() => handleDeleteCategoryClick(category.id)}></i></div>
                                                    <div className='col text-start mb-2'>Wiek:</div>
                                                    <div className='col text-end mb-2'>{category.ageRange}</div>
                                                    <div className='col text-start mb-2'>Klasa:</div>
                                                    <div className='col text-end mb-2'>{category.categoryDanceClass}</div>
                                                    <div className='col text-start mb-2'>Lista par:</div>
                                                </div>
                                                <div className='row row-cols-3'>
                                                    <div className='col text-start mb-1'><strong>Nr:</strong></div>
                                                    <div className='col text-center mb-1'><strong>Tancerz:</strong></div>
                                                    <div className='col text-end mb-1'><strong>Partner:</strong></div>
                                                </div>
                                                {category.listofPairs.map((pair, index) => (
                                                    <div className='row row-cols-3'>
                                                        <div className='col text-start mb-1'>{index + 1}</div>
                                                        <div className='col text-center mb-1'>{pair.dancerName}</div>
                                                        <div className='col text-end mb-1'>{pair.dancePartnerName}</div>
                                                    </div>
                                                ))}
                                                <hr />
                                            </div>
                                        ))}
                                    </div>
                                    <div className='text-center'>
                                        <a href="/dashboard" class="btn btn-primary">Powrót</a>

                                        {token && (
                                            <div>
                                                <div>
                                                    <a href={`/event/category/${event.id}`} className="btn btn-success mt-2">Dodaj kategorię</a>
                                                </div>
                                                <div>
                                                    <a className="btn btn-success mt-2" data-bs-toggle="modal" data-bs-target="#addPair">Dodaj parę</a>
                                                </div>
                                                <div>
                                                    <a href={`/event/delete/${event.id}`} className="btn btn-danger mt-2">Usuń wydarzenie</a>
                                                </div>
                                            </div>
                                        )}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <p>Loading event details...</p>
                )}
            </div>
            <div class="modal fade" id="deleteCategory" tabindex="-1" aria-labelledby="deleteCategoryLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="deleteCategoryLabel">Usuwanie kategorii</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Czy chcesz usunąc kategorię #{categoryId}?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                            <button type="button" class="btn btn-danger" onClick={() => handleDeleteCategory()}>Usuń</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="addPair" tabindex="-1" aria-labelledby="addPairLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="addPairLabel">Dodawanie pary do wydarzenia</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={handleAddCompetitionPair}>
                            <div class="modal-body">
                                <div className="row">
                                    <div className="mb-4">
                                        <div className="form-floating">
                                            {pairs ? (
                                                <select class="form-select" aria-label="Default select example" onChange={(e) => setPairId(e.target.value)}>
                                                    <option selected value='0'>Proszę wybrać</option>
                                                    {pairs.map(pair => (
                                                        <option key={pair.id} value={pair.id}>{pair.dancerName} & {pair.dancePartnerName}</option>
                                                    ))}
                                                </select>
                                            ) : (
                                                <p>Loading event details...</p>
                                            )}
                                            <label>Wybór pary</label>
                                            <div className='invalid-feedback'></div>
                                        </div>
                                    </div>
                                    <div className="mb-4">
                                        <div className="form-floating">
                                            {event ? (
                                                <select class="form-select" aria-label="Default select example" onChange={(e) => setCategoryIdAdd(e.target.value)}>
                                                    <option selected value='0'>Proszę wybrać</option>
                                                    {event.danceCompetitionCategories.map((category) => (
                                                        <option key={category.id} value={category.id}>{category.id} | {category.ageRange} | {category.categoryDanceClass}</option>
                                                    ))}
                                                </select>
                                            ) : (
                                                <p>Loading event details...</p>
                                            )}
                                            <label>Wybór kategorii</label>
                                            <div className='invalid-feedback'></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zamknij</button>
                                <button type="submit" class="btn btn-success">Zapisz</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
