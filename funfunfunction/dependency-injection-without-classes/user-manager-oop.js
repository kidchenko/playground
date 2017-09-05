class UserManager {
    constructor(connection) {
        this._connection = connection;
    }

    createUser(name) {
        return this._connection.table('user').insert({
            is_new: true,
            full_name: name
        }).then(user => user.id);
    }
}

export default UserManager;