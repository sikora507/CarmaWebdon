import React from 'react';
import { render } from 'react-dom';
import { Router, Route, Link, IndexRoute, browserHistory   } from 'react-router';
import App from './App';
import UpperNavbarContainer from './Navigation/UpperNavbarContainer';
import PixChooser from './Pix/PixChooser';
import PixContentBrowser from './Pix/PixContentBrowser';
import PixPreview from './Pix/PixPreview';
import CarsBrowser from './Cars/CarsBrowser';
import MapsBrowser from './MapsBrowser';
import PaletteChooser from './PaletteChooser';
import CarPreview from './Cars/CarPreview';

render(
    <Router history={browserHistory}>
        <Route path="/" component={App}>
            <Route path="/pix" component={PixChooser}>
                <Route path=":pixDirId" component={PaletteChooser} >
                    <Route path="palette/:paletteId" component={PixContentBrowser}>
                        <Route path="preview/:pixIndex" component={PixPreview} />
                    </Route>
                </Route>
            </Route>
            <Route path="/cars" component={CarsBrowser} >
                <Route path=":carId" component={CarPreview} />
            </Route>
            <Route path="/maps" component={MapsBrowser} />
        </Route>
    </Router>
    , document.getElementById('app')); 