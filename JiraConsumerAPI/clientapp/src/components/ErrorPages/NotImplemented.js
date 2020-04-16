import React from 'react';
import './NotImplemented.css'
import Navigation from '../Navigation/Navigation';
 
const notImplemented = (props) => {
    return (
        <div className = {"root"}>
            <Navigation/>
            <main className={"content"}>
                <p className={'notFound'}>
                    "This feature is not implemented yet !!"
                </p>
            </main> 
        </div>
    );
}
 
export default notImplemented;