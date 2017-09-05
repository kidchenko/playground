import db from 'unicor-db';
import App from './some-app';
import { makeCreateUser } from './user-manager-func';

const connection = new db.Connection({
    host: 'somehost.com',
    port: 2121
});

const createUser = new makeCreateUser(connection);

createUser('juca');

const app = new App(userManager);
app.start();