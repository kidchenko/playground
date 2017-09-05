export const makeCreateUser = connection => name =>
    connection.table('user').insert({
        is_new: true,
        full_name: name
    }).then(user => user.id)