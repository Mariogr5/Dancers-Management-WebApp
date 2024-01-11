import React from 'react';
import Navbar from '../Navbar/Navbar'
import Events from '../Events/Events';
import useToken from '../useToken';

export default function EventAdd() {
  const { token } = useToken();

  return (
    <div className="wrapper">
      <Navbar />
      <Events />
      <div className='text-center'>
        {token && (
          <div>
              <a href={`/eventAdd`} className="btn btn-primary mt-2">Dodaj wydarzenie</a>
          </div>
        )}
      </div>
    </div>
  );
}