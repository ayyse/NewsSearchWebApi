import { ACTION_TYPES } from "../actions/news";

const initialState = {
    list: []
}

export const news = (state = initialState, action) => {
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload]
            }

        default:
            return state;
    }
}