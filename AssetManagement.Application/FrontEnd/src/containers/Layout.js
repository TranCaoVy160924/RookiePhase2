import { Layout } from 'react-admin';
import React from 'react';
import { MenuBar } from '../components/menu';

export const MyLayout = props => <Layout {...props} menu={MenuBar} />;