import '../App.css';
import ToDoItem from "../components/ToDoItem";
import 'bulma/css/bulma.css';

const HomePage = () =>
{

    return (
        <div>
            <nav className="navbar" role="navigation" aria-label="main navigation">
                <div id="navbarBasicExample" className="navbar-menu">
                <div className="navbar-start">
                    <a className="navbar-item" href="/">
                    Home
                    </a>

                    <a className="navbar-item" href="https://github.com/brandongallagher1999/CrypTorrents-React-FastAPI">
                    Documentation
                    </a>

                    
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

        <div className="container-1">
            <ToDoItem></ToDoItem>
        </div>
        </div>
    );

}

export default HomePage;