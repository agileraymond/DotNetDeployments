import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ProjectState {
}

export class Project extends React.Component<RouteComponentProps<{}>, ProjectState> {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };
        /*
        fetch('api/SampleData/WeatherForecasts')
            .then(response => response.json() as Promise<WeatherForecast[]>)
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
            */
    }
}
