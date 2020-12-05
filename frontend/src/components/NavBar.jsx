import '../App.css';
import ToDoItem from "../components/ToDoItem";
import 'bulma/css/bulma.css';
import { useEffect } from 'react';

import Siema from 'siema';

const NavBar = () =>
{

    useEffect(() => {
        new Siema({
            selector: '.siema',
            duration: 200,
            easing: 'ease-out',
            perPage: 1,
            startIndex: 0,
            draggable: true,
            multipleDrag: true,
            threshold: 20,
            loop: false,
            rtl: false,
            onInit: () => {},
            onChange: () => {},
          });
    });

    return (
        <div>
            <nav className="navbar" role="navigation" aria-label="main navigation">
                <div id="navbarBasicExample" className="navbar-menu">
                <div className="navbar-start">
                    <a className="navbar-item" href="/">
                    Home
                    </a>

                    

                    <div className="navbar-item has-dropdown is-hoverable">
                        <a className="navbar-link">
                        More
                        </a>
                        <div className="navbar-dropdown">
                            <a className="navbar-item" href="https://github.com/brandongallagher1999/CrypTorrents-React-FastAPI">
                            Documentation
                            </a>

                            <a className="navbar-item" href="/crud">
                            CRUD Page
                            </a>
                        </div>
                        
                    </div>
                    
                </div>

                    <div className="navbar-end">
                    <div className="navbar-item">
                        <div className="buttons">
                        <a className="button is-light" href="/login/">
                            Log in
                        </a>
                        </div>
                    </div>
                    </div>
                    
                </div>
            </nav>

            <div class="siema" style={{position: "relative", margin: "auto", width: "50%", height: "400px", marginTop: "10px"}}>
                <div><img src="https://thumbor.forbes.com/thumbor/fit-in/1200x0/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fdam%2Fimageserve%2F1092571024%2F0x0.jpg%3Ffit%3Dscale"></img></div>
                <div><img src="https://blog.hubspot.com/hubfs/To_Do_List.png"></img></div>
                <div><img src="https://miro.medium.com/max/2800/1*oyzl9-P13xwow7zZXAeoqA.jpeg"></img></div>
            </div>
        
        </div>
    );

}

export default NavBar;