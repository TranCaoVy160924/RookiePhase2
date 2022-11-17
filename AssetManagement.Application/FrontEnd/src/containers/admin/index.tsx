import React from 'react';
import { Admin, Resource, ListGuesser, ShowGuesser } from "react-admin";
import Layout from '../Layout';
import jsonServerProvider from "ra-data-json-server";
import simpleRestProvider from 'ra-data-simple-rest';
import { theme } from '../../theme';

const dataProvider = jsonServerProvider("https://jsonplaceholder.typicode.com");
// const dataProvider = simpleRestProvider('https://localhost:5001 ');
const App = () => (
    <Admin dataProvider={dataProvider} theme={theme} layout={Layout}>
        <Resource name="users" list={ListGuesser} show={ShowGuesser} />
    </Admin>
);

export default App;