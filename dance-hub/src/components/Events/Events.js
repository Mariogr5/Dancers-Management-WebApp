import React, { useState, useEffect } from 'react';
import format from 'date-fns/format';
import './Events.css';

export default function Events() {
    const [events, setEvents] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7234/DanceEvent')
            .then(response => response.json())
            .then(data => setEvents(data));
    }, []);

    const formattedDate = (dateString) => {
        const date = new Date(dateString);
        return format(date, 'dd.MM.yyyy');
    };

    const formattedTime = (dateString) => {
        const date = new Date(dateString);
        return format(date, 'HH:mm');
    };

    console.log(events);

    return (
        <div>
            <div className='d-flex justify-content-center mt-100'>
                <div class="col-lg-8 col-md-10 col-sm-11 col-11 text-left">
                    <h2><i class="fa-solid fa-people-pulling"></i> Wydarzenia</h2>
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
                                <th scope="col">Data</th>
                                <th scope="col">Godzina</th>
                                <th scope="col">Nazwa</th>
                                <th scope="col">Organizator</th>
                                <th scope="col">Miejsce</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody className='table-group-divider'>
                            {events.map(event => (
                                <tr key={event.id}>
                                    <td>{event.id}</td>
                                    <td>{formattedDate(event.date)}</td>
                                    <td>{formattedTime(event.date)}</td>
                                    <td>{event.name}</td>
                                    <td>{event.organizer}</td>
                                    <td>{event.city}</td>
                                    <td><a class="nav-link" href={`/event/${event.id}`}><i class="fa-solid fa-arrow-up-right-from-square"></i></a></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}