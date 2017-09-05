import db from 'unicor-db';
import App from './some-app';
import UserManager from './user-manager';

const connection = new db.Connection({
    host: 'somehost.com',
    port: 2121
});

const userManager = new UserManager(connection);

const app = new App(userManager);
app.start();