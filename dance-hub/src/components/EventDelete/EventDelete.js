import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Navbar from '../Navbar/Navbar';
import './EventDelete.css';
import useToken from '../useToken';

export default function EventDelete() {
    const { id } = useParams();
    const [event, setEvent] = useState(null);
    const { token } = useToken();

    useEffect(() => {
        fetch(`https://localhost:7234/DanceEvent/${id}`)
            .then(response => response.json())
            .then(data => setEvent(data))
            .catch(error => console.error('Error fetching event details:', error));
    }, [id]);

    const handleDelete = () => {
        fetch(`https://localhost:7234/DanceEvent/${id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Accept': '*/*',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = "/";
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
            <div className='row justify-content-center'>
                <div className='col-sm-6 mb-3 mb-sm-0 card text-bg-warning mb-3 mt-100'>
                    <div class="card-header">Uwaga!</div>
                    <div class="card-body">
                        <h5 class="card-title">Usuwasz wydarzenie</h5>
                        <p class="card-text">Czy na pewno chcesz usunąć wydarzenie <strong>#{id}</strong>.</p>
                        <button class="btn btn-danger mt-1 mb-1" onClick={() => { handleDelete(); }}>Tak</button>
                        <a href={`/event/${id}`} className="btn btn-secondary m-1">Nie</a>
                    </div>
                </div>
            </div>
        </div>
    );
}