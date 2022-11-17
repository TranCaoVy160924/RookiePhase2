import React from 'react';
import jsonServerProvider from "ra-data-json-server";
import simpleRestProvider from 'ra-data-simple-rest';
import { 
    Admin, 
    Resource, 
    NotFound, 
    ListGuesser, 
    ShowGuesser 
} from "react-admin";
import { theme } from '../../theme';
import { AuthProvider } from '../../pages/login';
import Layout from '../Layout';

const dataProvider = jsonServerProvider("https://jsonplaceholder.typicode.com");
// const dataProvider = simpleRestProvider('https://localhost:5001 ');

// You will fix this API-URL
const authProvider = AuthProvider('https://localhost:7173')

const App = () => (
    <Admin 
        title="Nashtech" 
        dataProvider={dataProvider} 
        authProvider={authProvider}
        theme={theme} 
        layout={Layout}
        catchAll={NotFound}
        // loginPage={MyLoginPage}
        // requireAuth={true}
    >
        <Resource name="users" list={ListGuesser} show={ShowGuesser} />
    </Admin>
);

export default App;